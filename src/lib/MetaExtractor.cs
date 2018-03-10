using System;
using System.Collections.Generic;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ImageRenamer
{
    public class MetaExtractor
    {
        public MetaResult GetMetaDataFromFile(string imageFilePath)
        {
            var result = new MetaResult();
            
            // https://github.com/drewnoakes/metadata-extractor/wiki/Getting-Started-(dotnet)
            var directories = ImageMetadataReader.ReadMetadata(imageFilePath);

            result.OriginalDateTime = GetOriginalDateTime(directories);

            return result;
        }

        private DateTime? GetOriginalDateTime(IList<Directory> directories)
        {
            foreach (var directory in directories)
            {
                if (directory.TryGetDateTime(ExifDirectoryBase.TagDateTimeOriginal, out var dateTime))
                    return dateTime;
            }

            return null;
        }
    }
}