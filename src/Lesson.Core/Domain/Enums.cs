using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain
{
    public enum RollCallType
    {
        [Display(Name ="Sınıfta")]
        Here=0,
        [Display(Name ="Sınıfta Değil")]
        NotHere=1,
        [Display(Name ="İzinli")]
        Permit=2
    }
}
