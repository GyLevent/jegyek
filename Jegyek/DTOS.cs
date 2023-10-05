namespace Jegyek
{
    public class DTOS
    {
        public record MarkDTO(Guid Id, int Mark,string Description,string CreatedTime);
        public record CreateMark(Guid Id,int Mark,string Description);
        public record UpdateMark(int Mark,string Description);
    }
}
