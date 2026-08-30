using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess_Layer;
using System.Data;

namespace DVLD_Buisness_Layer
{
    public class clsCountry
    {
        public int ID { set; get; }
        public string CountryName { set; get; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";
        }

        private clsCountry(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryInfoByID(ID, ref CountryName))
                return new clsCountry(ID, CountryName);
            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int ID = -1;

            if (clsCountryData.GetCountryInfoByName(CountryName, ref ID))
                return new clsCountry(ID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
