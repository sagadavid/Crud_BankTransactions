using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Crud_BankTransactions.Models
{
    public class TransactionsModel
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("account number")]
        [Required(ErrorMessage ="Oblig er det")]
        [MaxLength(12, ErrorMessage ="12 char stykker er tillat")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("benifico navn")]
        [Required(ErrorMessage = "Oblig er det")]
        public string BeneficiaryName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("bank sin navn")]
        [Required(ErrorMessage = "Oblig er det")]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("swift kod")]
        [Required(ErrorMessage = "Oblig er det")]
        [MaxLength(11, ErrorMessage = "11 char stykker er tillat")]
        public string SWIFTcode { get; set; }

        [Required(ErrorMessage = "Oblig er det")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:MMM-dd-yy}")]
        public DateTime Date { get; set; }

    }
}
