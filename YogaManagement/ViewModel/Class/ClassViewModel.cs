using YogaManagement.Common;

namespace YogaManagement.ViewModel.Class
{
    public class ClassViewModel : BaseViewModel
    {
        public string ClassName { get; set; }
        public string ClassType { get; set; }
        public string MonthPeriod { get; set; }
    }

    //public class RegisterClassVM : ClassViewModel
    //{
    //    public List<string> TypeOptions = new List<string> {
    //        DaysInWeek.Three.ToString(),
    //        DaysInWeek.Five.ToString(),
    //        DaysInWeek.Mix.ToString()
    //    };
    //}
}
