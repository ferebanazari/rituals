using System.ComponentModel.DataAnnotations;

namespace RitualsAPI.Models
{

    public class Dressinger
    {

        [Key]
        public int Id { get; set; }

        public string ImgName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }


    }




}