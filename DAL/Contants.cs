using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Constants
    {
        public const int EMPTY = 0;
        public const int FAILURE = -1;
        public const int AlreadExists = -2;
        public const int SUCCESS = 1;

        public const string MessageEmpty = "No Data Found";
        public const string MessageAlreadExists = "Data Already Exists";
        public const string MessageDBConnectivityFailure = "Unable to Open DataBase Connection";
        public const string MessageSuccessUpate = "Data Updated Successfully";
        public const string MessageSuccessSave = "Data Save Successfully";
        public const string MessageSuccessDelete = "Data Delete Successfully";


    }
}
