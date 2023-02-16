
namespace GigHub.Core.Models
{
    public class Genre
    {
        // 256'dan fazla tür adı olmayacağı için Id'nin byte tipinde olmasında bi sakınca olmaz. 
        public byte Id { get; set; }

        public string Name { get; set; }
    }
}