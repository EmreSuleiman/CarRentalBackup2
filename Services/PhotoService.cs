using CarRental3._0.Helpers;
using CarRental3._0.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace CarRental3._0.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger<PhotoService> _logger;

        public PhotoService(IOptions<CloudinarySettings> config, ILogger<PhotoService> logger)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
            _logger = logger;
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("Файлът е празен");
                }

                // Validate file type
                var validExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!validExtensions.Contains(extension))
                {
                    throw new ArgumentException("Невалиден файл");
                }

                // Validate file size (max 5MB)
                if (file.Length > 5 * 1024 * 1024)
                {
                    throw new ArgumentException("Файлът е по-голям от 5MB");
                }

                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation()
                        .Height(500)
                        .Width(800)
                        .Crop("fill")
                        .Quality("auto")
                };

                return await _cloudinary.UploadAsync(uploadParams);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading photo to Cloudinary");
                throw;
            }
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(publicUrl))
                {
                    throw new ArgumentException("Public URL is required");
                }

                // Extract public ID from URL
                var publicId = GetPublicIdFromUrl(publicUrl);
                if (string.IsNullOrEmpty(publicId))
                {
                    throw new ArgumentException("Invalid Cloudinary URL");
                }

                var deleteParams = new DeletionParams(publicId);
                return await _cloudinary.DestroyAsync(deleteParams);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting photo from Cloudinary");
                throw;
            }
        }

        private string GetPublicIdFromUrl(string url)
        {
            var uri = new Uri(url);
            var segments = uri.Segments;
            var lastSegment = segments.Last();
            return Path.GetFileNameWithoutExtension(lastSegment);
        }
    }
}
