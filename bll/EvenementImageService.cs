using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using bo;
using dal;
using File = Tools.File;

namespace bll
{
    public class EvenementImageService
    {

        private BasicRepository<EvenementImage> evtImageRepository;

        public EvenementImageService()
        {
            this.evtImageRepository = new BasicRepository<EvenementImage>();
        }

        public EvenementImage UploadAndCreate(HttpPostedFileBase file)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", file.FileName);
            File.UploadHttpFile(file, path);

            var evtImage = new EvenementImage()
            {
                Title = file.FileName,
                Path = path
            };
            evtImageRepository.Create(evtImage);

            return evtImage;
        }

        public void Create(EvenementImage evtImage)
        {
            this.evtImageRepository.Create(evtImage);
        }

        public void Update(EvenementImage evtImage)
        {
            this.evtImageRepository.Update(evtImage);
        }

        public EvenementImage Find(int id)
        {
            return this.evtImageRepository.Find(id);
        }

        public List<EvenementImage> FindAll()
        {
            return this.evtImageRepository.FindAll();
        }

        public void Remove(EvenementImage evtImage)
        {
            Tools.File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, evtImage.Path));
            this.evtImageRepository.Remove(evtImage);
        }
        
    }
}
