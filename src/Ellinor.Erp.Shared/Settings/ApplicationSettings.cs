namespace Ellinor.Erp.Shared.Settings
{
    public record ApplicationSettings
    {
        public required string UploadedImagesDirectory { get; init; }
    }
}
