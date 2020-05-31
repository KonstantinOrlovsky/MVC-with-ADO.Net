using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer
{
    public class EmployeeDTO
    {
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Некорректный ввод")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [Display(Name = Constants.Surname)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Некорректный ввод")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [Display(Name = Constants.Name)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Некорректный ввод")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [Display(Name = Constants.Patronymic)]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[0-9]{2}\/[0-9]{2}\/[0-9]{4}", ErrorMessage = "Некорректный ввод")]
        [Display(Name = Constants.Date)]
        public string Date { get ; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Некорректный ввод")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        [Display(Name = Constants.Post)]
        public string Post { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = Constants.Company)]
        public int? CompanyId { get; set; }
        public CompanyDTO Company { get; set; }
    }
}



