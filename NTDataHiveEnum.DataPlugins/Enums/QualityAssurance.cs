using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDataHiveEnum.DataPlugins.Enums
{
    public enum QualityAssurance
    {
        Anitha,
        [Description("Deovic Intong")] 
        Deovic_Intong,
        [Description("Girlie Quio")] 
        Girlie_Quio,
        Jelou_Fon,
        Joy_Pactol,
        Nirmala,
        Rajalakshmi,
        Ruel_Amaro,
        Others,
    }    
    
}
