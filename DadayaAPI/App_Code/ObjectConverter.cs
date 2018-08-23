
namespace DadayaAPI
{
    using System.Threading.Tasks;

    using DadayaAPI.Data;
    using DadayaAPI.Models;

    public class ObjectConverter
    {
        public static async Task<Gallery> ToGallery(GalleryModel galleryModel)
        {
            return new Gallery
                       {
                           GalleryTypeId = galleryModel.GalleryTypeId,
                           Description = galleryModel.Description,
                           ImagePath = await UploadFile.SaveFileInWebRoot(galleryModel.Image, ""),
                           MainImage = galleryModel.MainImage,
                           Name = galleryModel.Name,
                           Id = galleryModel.Id
            };
        }

        public static async Task<Notice> ToNotice(NoticeModel noticeModel)
        {
            return new Notice
                       {
                           Description = noticeModel.Description,
                           Id = noticeModel.Id,
                           ImagePath = await UploadFile.SaveFileInWebRoot(noticeModel.Image, ""),
                           DateCreated = noticeModel.DateCreated,
                           Heading = noticeModel.Heading
            };
        }

        public static async Task<Event> ToEvent(EventModel eventModel)
        {
            return new Event
                       {
                           Description = eventModel.Description,
                           Id = eventModel.Id,
                           ImagePath = await UploadFile.SaveFileInWebRoot(eventModel.Image, ""),
                           DateCreated = eventModel.DateCreated,
                           Heading = eventModel.Heading,
                           DateOfEvent = eventModel.DateOfEvent
                       };
        }

        public static async Task<Staff> ToStaff(StaffModel model)
        {
            return new Staff{
                           ImagePath = await UploadFile.SaveFileInWebRoot(model.Image, ""),
                           Id = model.Id,
                           DateCreated = model.DateCreated,
                           Email = model.Email,
                           FullName = model.FullName,
                           Phonenumber = model.Phonenumber,
                           Position = model.Position,
                           UserId = model.UserId
            };
        }

        public static async Task<Project> ToProject(ProjectModel model)
        {
            return new Project
                       {
                           Id = model.Id,
                           ImagePath = await UploadFile.SaveFileInWebRoot(model.Image, ""),
                           Name = model.Name,
                           DateCreated = model.DateCreated,
                           Description = model.Description
            };
        }
    }
}
