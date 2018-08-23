
namespace DadayaAPI
{
    using System.Collections.Generic;
    using System.Linq;

    using DadayaAPI.Controllers;

    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class FileUploadOperation: IOperationFilter
    {
        private readonly IEnumerable<string> actionsWithUpload = new[]
                                                                     {
                                                                         "Api"+NamingHelpers.GetOperationId<GalleriesController>(nameof(GalleriesController.PostGallery)),
                                                                         "Api"+NamingHelpers.GetOperationId<GalleriesController>(nameof(GalleriesController.PutGallery))
                                                                     };
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (actionsWithUpload.Contains(operation.OperationId))
            {
                operation.Parameters.Remove(new BodyParameter { Name = "ProfileImage" });
                operation.Parameters.Add(new NonBodyParameter
                                             {
                                                 Name = "ProfileImage",
                                                 In = "formData",
                                                 Description = "Upload Image",
                                                 Required = false,
                                                 Type = "file"
                                             });
                operation.Consumes.Add("multipart/form-data");
            }
        }
    }
}
