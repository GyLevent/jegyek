namespace Jegyek
{
    public class DTOS
    {
        public record CreateMark(Guid id,int Mark,string Description,string CreatedTime);
        public record UpdateMark(int Mark,string Description);
    }
}
