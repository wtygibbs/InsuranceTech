using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceTech.Models
{ 
    public class Insurance
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Primary Address")]
        public string Address1 { get; set; }

        [Display(Name = "Secondary Address")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Total Insured Value")]
        [DisplayFormat(DataFormatString = "{0:$0.00}")]
        public decimal TotalInsuredValue { get; set; }

        [Display(Name = "Business Type")]
        public EnumBusiness Business { get; set; }

        public enum EnumBusiness
        {
            Corporation,
            Partnership,
            LimitedLiabilityCompany,
            LLC
        }

        public decimal Rate { get; set; } = 1.0M;

        [DisplayFormat(DataFormatString = "{0:$0.00}")]
        public decimal Premium { get; set; }

        public Insurance()
        { 
        }

        public decimal calculatePremium(string st, decimal tiv, decimal r)
        {
            if(st.ToUpper().Equals("FL") || st.ToUpper().Equals("FLORIDA"))
            {
                return (tiv * (r + 0.07M)) / 100;
            }

            return (tiv * r) / 100;
        }
    }
}
