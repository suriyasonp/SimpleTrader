using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexViewModel
    {
        public readonly IMajorIndexService _majorIndexService;

        public MajorIndex Apple { get; set; }
        public MajorIndex Facebook { get; set; }
        public MajorIndex SP500 { get; set; }


        public MajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexViewModel majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.Apple).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Apple = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.Facebook).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Facebook = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });
        }
    }
}
