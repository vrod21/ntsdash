﻿using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NLog;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.Model;
using System.Security.Cryptography;

namespace NTDataHiveGrpcService.DAL.GAP.Adapters
{
    public class EvaluationRecordAdapter
    {
        private static readonly Logger _nlog = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _config;
        private DbContextOptions<NTDataHiveContext> _contextOptions;
        private TimeZoneInfo _currentTimeZone;

        public EvaluationRecordAdapter(IConfiguration config)
        {
            _config = config;
            var optionsBuilder = new DbContextOptionsBuilder<NTDataHiveContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("connectionString"));
            _contextOptions = optionsBuilder.Options;
        }

        private void LoadConfiguration()
        {
            var tz = _config.GetValue<string>("UTC");
            _currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById(tz);
        }

        #region InsertPreEditingErrorFeedback
        internal void Insert(FeedbackRecordRequest recordRequest, out int feedbackId)
        {
            feedbackId = 0;
            try
            {
                if (recordRequest != null)
                {
                    using var dbContext = new NTDataHiveContext(_contextOptions);

                    var feedback = new Model.Evaluation()
                    {
                        WebId = recordRequest.WebId,
                        QualityAssurance = recordRequest.QualityAssurance,
                        PublisherName = recordRequest.PublisherName,
                        JournalId = recordRequest.JournalId,
                        ArticleId = recordRequest.ArticleId,
                        CopyEditedBy = recordRequest.CopyEditedBy,
                        PageCount = recordRequest.PageCount,
                        ErrorCount = recordRequest.ErrorCount,
                        DescriptionOfError = recordRequest.DescriptionOfError,
                        Matter = recordRequest.Matter,
                        ErrorLocation = recordRequest.ErrorLocation,
                        ErrorCode = recordRequest.ErrorCode,
                        ErrorType = recordRequest.ErrorType,
                        ErrorSubtype = recordRequest.ErrorSubtype,
                        ErrorCategory = recordRequest.ErrorCategory,
                        IntroducedOrMissed = recordRequest.IntroducedOrMissed,
                        Department = recordRequest.Department,
                        EmployeeName = recordRequest.EmployeeName,
                        CopyEditingLevel = recordRequest.CopyEditingLevel,
                        CreatedAt = recordRequest.CreatedAt.ToDateTime(),
                        MegaEvaluation =  feedbackId,
                    };
                    dbContext.Evaluation.Add(feedback);
                    _ = dbContext.SaveChanges();

                    feedbackId = feedback.Id;

                    var approval = new Model.Approval()
                    {
                        ApprovalIdExt = feedbackId,
                        RootCause = recordRequest.RootCause,
                        CorrectiveAction = recordRequest.CorrectiveAction,
                        NatureOfCA = recordRequest.NatureOfCA,
                        OwnerOfCA = recordRequest.OwnerOfCA,
                        PreventiveMeasure = recordRequest.PreventiveMeasure,
                        NatureOfPM = recordRequest.NatureOfPM,
                        OwnerOfPM = recordRequest.OwnerOfPM,
                        StatusOfCA = recordRequest.StatusOfCA,
                        StatusOfPM = recordRequest.StatusOfPM,       
                    };
                    dbContext.Approval.Add(approval);
                    _ = dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                throw;
            }
        }
        #endregion

        #region UpdateFeedback
        internal void UpdateFeedback(FeedbackRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var evals = from evaluation in dbContext.Evaluation
                                    join appEx in dbContext.Approval on evaluation.Id equals appEx.ApprovalIdExt
                                    where appEx.EvaluationNavigation.WebId == recordRequest.WebId
                                    select evaluation;

                var eval = evals.Single();

                eval.SupplierName = recordRequest.SupplierName.Trim();
                eval.QualityAssurance = recordRequest.QualityAssurance.Trim();
                eval.PublisherName = recordRequest.PublisherName.Trim();
                eval.JournalId = recordRequest.JournalId.Trim();
                eval.ArticleId = recordRequest.ArticleId.Trim();
                eval.CopyEditedBy = recordRequest.CopyEditedBy.Trim();
                eval.PageCount = recordRequest.PageCount;
                eval.ErrorCount = recordRequest.ErrorCount;
                eval.DescriptionOfError = recordRequest.DescriptionOfError.Trim();
                eval.Matter = recordRequest.Matter.Trim();
                eval.ErrorLocation = recordRequest.ErrorLocation.Trim();
                eval.ErrorCode = recordRequest.ErrorCode.Trim();
                eval.ErrorType = recordRequest.ErrorType.Trim();
                eval.ErrorSubtype = recordRequest.ErrorSubtype.Trim();
                eval.ErrorCategory = recordRequest.ErrorCategory.Trim();
                eval.IntroducedOrMissed = recordRequest.IntroducedOrMissed.Trim();
                eval.Department = recordRequest.Department.Trim();
                eval.EmployeeName = recordRequest.EmployeeName.Trim();
                eval.CopyEditingLevel = recordRequest.CopyEditingLevel.Trim();

                dbContext.Evaluation.Update(eval);

                var appExts = from approval in dbContext.Approval
                              where approval.EvaluationNavigation.WebId == recordRequest.WebId
                              select approval;

                var appExt = appExts.Single();

                appExt.RootCause = recordRequest.RootCause.Trim();
                appExt.CorrectiveAction = recordRequest.CorrectiveAction.Trim();
                appExt.NatureOfCA = recordRequest.NatureOfCA.Trim();
                appExt.OwnerOfCA = recordRequest.OwnerOfCA.Trim();
                appExt.TargetDateOfCompletionCA = recordRequest.TargetDateOfCompletionCA.ToDateTime();
                appExt.PreventiveMeasure = recordRequest.PreventiveMeasure.Trim();
                appExt.NatureOfPM = recordRequest.NatureOfPM.Trim();
                appExt.OwnerOfPM = recordRequest.OwnerOfPM.Trim();
                appExt.TargetDateOfCompletionPM = recordRequest.TargetDateOfCompletionPM.ToDateTime();
                appExt.StatusOfCA = recordRequest.StatusOfCA.Trim();
                appExt.StatusOfPM = recordRequest.StatusOfPM.Trim();

                dbContext.Approval.Update(appExt);

                _ = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
            }
        }
        #endregion

        #region GetAllFeedbackRecord
        internal List<FeedbackRecordRequest> GetAllFeedbackRecord()
        {
            List<FeedbackRecordRequest> feedback = new List<FeedbackRecordRequest>();
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var evaluations = (from evaluation in dbContext.Evaluation
                                   join appExt in dbContext.Approval on evaluation.Id equals appExt.ApprovalIdExt
                                   orderby appExt.EvaluationNavigation.CreatedAt descending                                   
                                   select CreateNewMapper(evaluation, appExt)).ToList();

                if (evaluations.Count > 0)
                {
                    return evaluations;
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal($"ex.Message");
            }
            return feedback;
        }
        #endregion

        #region SelectFeedbackByPublisherName
        internal bool SelectFeedbackByPublisherName(FeedbackRecordRequest request)
        {
            try
            {
                var record = new FeedbackRecordArray();
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var evals = (from eval in dbContext.Evaluation
                           join appro in dbContext.Approval on eval.Id equals appro.ApprovalIdExt
                           where appro.EvaluationNavigation.PublisherName == request.PublisherName
                           orderby appro.EvaluationNavigation.CreatedAt descending
                           select CreateNewMapper(eval, appro)).ToList();

                if (evals.Count >= 1)
                {
                    evals.ToList();
                    return true;
                }

                //if (evals.Count == 0)
                //{
                //    _nlog.Error($"No data found");
                //    return false;
                //}
                //else if (evals.Count >= 1)
                //{
                //    var eval = evals[0];
                //    request.SupplierName = eval.SupplierName?.Trim() ?? "";
                //    request.QualityAssurance = eval.QualityAssurance?.Trim() ?? "";
                //    request.PublisherName = eval.PublisherName?.Trim() ?? "";
                //    request.JournalId = eval.JournalId?.Trim() ?? "";
                //    request.ArticleId = eval.ArticleId?.Trim() ?? "";
                //    request.CopyEditedBy = eval.CopyEditedBy?.Trim() ?? "";
                //    request.PageCount = eval.PageCount;
                //    request.ErrorCount = eval.ErrorCount;
                //    request.DescriptionOfError = eval.DescriptionOfError?.Trim() ?? "";
                //    request.Matter = eval.Matter?.Trim() ?? "";
                //    request.ErrorLocation = eval.ErrorLocation?.Trim() ?? "";
                //    request.ErrorCode = eval.ErrorCode?.Trim() ?? "";
                //    request.ErrorType = eval.ErrorType?.Trim() ?? "";
                //    request.ErrorSubtype = eval.ErrorSubtype?.Trim() ?? "";
                //    request.ErrorCategory = eval.ErrorCategory?.Trim() ?? "";
                //    request.IntroducedOrMissed = eval.IntroducedOrMissed?.Trim() ?? "";
                //    request.Department = eval.Department?.Trim() ?? "";
                //    request.EmployeeName = eval.EmployeeName?.Trim() ?? "";
                //    request.CopyEditingLevel = eval.CopyEditingLevel?.Trim() ?? "";
                //    request.CreatedAt = eval.CreatedAt.ToUniversalTime().ToTimestamp();

                //var appExt = (from approval in dbContext.Approval
                //              where approval.EvaluationNavigation.PublisherName == request.PublisherName
                //              select approval).ToList();

                //request.RootCause = appExt.RootCause?.Trim() ?? "";
                //request.CorrectiveAction = appExt.CorrectiveAction?.Trim() ?? "";
                //request.NatureOfCA = appExt.NatureOfCA?.Trim() ?? "";
                //request.OwnerOfCA = appExt.OwnerOfCA?.Trim() ?? "";
                //request.TargetDateOfCompletionCA = appExt.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp();
                //request.PreventiveMeasure = appExt.PreventiveMeasure?.Trim() ?? "";
                //request.NatureOfPM = appExt.NatureOfPM?.Trim() ?? "";
                //request.OwnerOfPM = appExt.OwnerOfPM?.Trim() ?? "";
                //request.TargetDateOfCompletionPM = appExt.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp();
                //request.StatusOfCA = appExt.StatusOfCA?.Trim() ?? "";
                //request.StatusOfPM = appExt.StatusOfPM?.Trim() ?? "";

                return true;
                //}
                //else
                //{
                //    _nlog.Error($"No data in feedback");
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex.Message );
                throw;
            }
        }
        #endregion

        #region SelectFeedbackPart
        internal bool SelectFeedbackPart(FeedbackRecordRequest recordRequest)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);

                var evals = (from eval in dbContext.Evaluation
                                      join appExt in dbContext.Approval on eval.Id equals appExt.ApprovalIdExt
                                      where appExt.EvaluationNavigation.WebId == recordRequest.WebId
                                      select eval).ToList();

                if (evals.Count == 0)
                {
                    _nlog.Error($"No data found");
                    return false;
                }
                else if (evals.Count == 1)
                {
                    var eval = evals[0];
                    recordRequest.QualityAssurance = eval.QualityAssurance?.Trim() ?? "";
                    recordRequest.PublisherName = eval.PublisherName?.Trim() ?? "";
                    recordRequest.JournalId = eval.JournalId?.Trim() ?? "";
                    recordRequest.ArticleId = eval.ArticleId?.Trim() ?? "";
                    recordRequest.CopyEditedBy = eval.CopyEditedBy?.Trim() ?? "";
                    recordRequest.PageCount = eval.PageCount;
                    recordRequest.ErrorCount = eval.ErrorCount;
                    recordRequest.DescriptionOfError = eval.DescriptionOfError?.Trim() ?? "";
                    recordRequest.Matter = eval.Matter?.Trim() ?? "";
                    recordRequest.ErrorLocation = eval.ErrorLocation?.Trim() ?? "";
                    recordRequest.ErrorCode = eval.ErrorCode?.Trim() ?? "";
                    recordRequest.ErrorType = eval.ErrorType?.Trim() ?? "";
                    recordRequest.ErrorSubtype = eval.ErrorSubtype?.Trim() ?? "";
                    recordRequest.ErrorCategory = eval.ErrorCategory?.Trim() ?? "";
                    recordRequest.IntroducedOrMissed = eval.IntroducedOrMissed?.Trim() ?? "";
                    recordRequest.Department = eval.Department?.Trim() ?? "";
                    recordRequest.EmployeeName = eval.EmployeeName?.Trim() ?? "";
                    recordRequest.CopyEditingLevel = eval.CopyEditingLevel?.Trim() ?? "";
                    recordRequest.CreatedAt = eval.CreatedAt.ToUniversalTime().ToTimestamp();

                    var appExt = (from approval in dbContext.Approval
                                  where approval.EvaluationNavigation.WebId == recordRequest.WebId
                                  select approval).Single();

                    recordRequest.RootCause = appExt.RootCause?.Trim() ?? "";
                    recordRequest.CorrectiveAction = appExt.CorrectiveAction?.Trim() ?? "";
                    recordRequest.NatureOfCA = appExt.NatureOfCA?.Trim() ?? "";
                    recordRequest.OwnerOfCA = appExt.OwnerOfCA?.Trim() ?? "";
                    recordRequest.TargetDateOfCompletionCA = appExt.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp();
                    recordRequest.PreventiveMeasure = appExt.PreventiveMeasure?.Trim() ?? "";
                    recordRequest.NatureOfPM = appExt.NatureOfPM?.Trim() ?? "";
                    recordRequest.OwnerOfPM = appExt.OwnerOfPM?.Trim() ?? "";
                    recordRequest.TargetDateOfCompletionPM = appExt.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp();
                    recordRequest.StatusOfCA = appExt.StatusOfCA?.Trim() ?? "";
                    recordRequest.StatusOfPM = appExt.StatusOfPM?.Trim() ?? "";

                    return true;
                }
                else
                {
                    _nlog.Error($"Webid {recordRequest.WebId} duplicate feedback");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return false;
            }
        }
        #endregion

        #region GetEvaluationFeedbackByWebId
        internal int GetFeedbackByWebId(string webid)
        {
            try
            {
                using var dbContext = new NTDataHiveContext(_contextOptions);
                var getFeedbackById = from feedback in dbContext.Approval
                                      where feedback.EvaluationNavigation.WebId == webid
                                      select feedback;

                if (getFeedbackById.Count() > 0)
                    return getFeedbackById.FirstOrDefault().ApprovalIdExt;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                _nlog.Fatal(ex);
                return 0;
            }
        }
        #endregion

        #region CreateNewBLLPreEditing
        private static FeedbackRecordRequest CreateNewMapper(Evaluation evaluation, Approval approval)
        {
            return new FeedbackRecordRequest()
            {
                WebId = evaluation.WebId,
                QualityAssurance = evaluation.QualityAssurance,
                PublisherName = evaluation.PublisherName,
                JournalId = evaluation.JournalId,
                ArticleId = evaluation.ArticleId,
                CopyEditedBy = evaluation.CopyEditedBy,
                PageCount = evaluation.PageCount,
                ErrorCount = evaluation.ErrorCount,
                DescriptionOfError = evaluation.DescriptionOfError,
                Matter = evaluation.Matter,
                ErrorLocation = evaluation.ErrorLocation,
                ErrorCode = evaluation.ErrorCode,
                ErrorType = evaluation.ErrorType,
                ErrorSubtype = evaluation.ErrorSubtype,
                ErrorCategory = evaluation.ErrorCategory,
                IntroducedOrMissed = evaluation.IntroducedOrMissed,
                Department = evaluation.Department,
                EmployeeName = evaluation.EmployeeName,
                RootCause = approval.RootCause,
                CorrectiveAction = approval.CorrectiveAction,
                NatureOfCA = approval.NatureOfCA,
                OwnerOfCA = approval.OwnerOfCA,
                TargetDateOfCompletionCA = approval.TargetDateOfCompletionCA.ToUniversalTime().ToTimestamp(),
                PreventiveMeasure = approval.PreventiveMeasure,
                NatureOfPM = approval.NatureOfPM,
                OwnerOfPM = approval.OwnerOfPM,
                TargetDateOfCompletionPM = approval.TargetDateOfCompletionPM.ToUniversalTime().ToTimestamp(),
                StatusOfCA = approval.StatusOfCA,
                StatusOfPM = approval.StatusOfPM,
                CopyEditingLevel = evaluation.CopyEditingLevel,
                CreatedAt = evaluation.CreatedAt.ToUniversalTime().ToTimestamp(),
            };        
        }
        #endregion
    }
}
