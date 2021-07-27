using AdvantureWork.Common.Helper;

namespace AdvantureWork.Common.ViewModel
{
    public class DataTableViewModel<T> : TransactionalInformation
    {
        public DataTableViewModel()
        {
        }

        public int draw { get; set; }
        public string error { get; set; }
        public long recordsFiltered { get; set; }
        public long recordsTotal { get; set; }
        public T[] data { get; set; }

        public int pagesTotal { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}