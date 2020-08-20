using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceTech.Models
{ 
    public class Insurance
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is Required.")]
        [Display(Name = "Primary Address")]
        public string Address1 { get; set; }

        [Display(Name = "Secondary Address")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is Required.")]
        [RegularExpression("[A-Za-z]+(?: [A-Za-z]+)*",
            ErrorMessage = "Invalid city format.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required.")]
        [RegularExpression("[a-zA-Z]+",
            ErrorMessage = "Invalid state format.")]
        public string State { get; set; }

        [RegularExpression("^[0-9]{5}(?:-[0-9]{4})?$", 
            ErrorMessage = "Zip code must be in either five digit(12345) or nine digit(12345-6789) form.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Effective Date")]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Total Insured Value is Required.")]
        [Display(Name = "Total Insured Value")]
        [DisplayFormat(DataFormatString = "{0:$0.00}")]
        public decimal TotalInsuredValue { get; set; }

        [Required(ErrorMessage = "Business type is Required.")]
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
