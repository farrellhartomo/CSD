using System.Collections.Generic;

namespace CSD
{
    class ClassDependency
    {
        public static IPDColl PDColl()
        {
            return new PDCollections();
        }

        public static List<IPersonalData> CRUDPersonDataList()
        {
            return new List<IPersonalData>();
        }
        public static IPersonalData CRUDPersonData()
        {
            return new PersonalData();
        }

    }
}
