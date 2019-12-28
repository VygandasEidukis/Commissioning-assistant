using commissioning_assistance.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Helpers
{
    public static class ImageHelper
    {
        public static List<ImageModel> GetImages(List<ImageModel> images = null)
        {
            if(images == null)
                images = new List<ImageModel>();

            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.Title = "Select pictures";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                foreach(var file in op.FileNames)
                {
                    var unique = true;
                    foreach(var image in images)
                    {
                        if (image.Path == file)
                            unique = false;
                    }

                    if(unique)
                        images.Add(new ImageModel(file));
                }
            }
            return images;
        }

        public static int NextInCycle(List<ImageModel> images, ImageModel currentImage)
        {
            int currentIndex = images.IndexOf(currentImage) + 1;
            if (currentIndex >= images.Count)
            {
                currentIndex = 0;
            }

            return currentIndex;
        }

        public static int PreviousInCycle(List<ImageModel> images, ImageModel currentImage)
        {
            int currentIndex = images.IndexOf(currentImage) - 1;
            if (currentIndex <= -1)
            {
                currentIndex = images.Count-1;
            }

            return currentIndex;
        }
    }
}
