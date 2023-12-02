using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NTDataHiveGrpcService.DAL.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
