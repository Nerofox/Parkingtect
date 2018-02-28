using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using dal;
using bo;
using File = Tools.File;

namespace bll
{
    public class EvenementService
    {
        private EvenementRepository eventRepository;

        public EvenementService()
        {
            this.eventRepository = new EvenementRepository();
        }

        public List<Evenement> FindAll()
        {
            return this.eventRepository.FindAll();
        }

        public Evenement Find(int id)
        {
            var evtImageRepository = this.eventRepository.CreateRepository<EvenementImage>();
            var evt = this.eventRepository.Find(id);
            evt.Images = evtImageRepository.FindAll().Where(img => img.Evenement.Id == id).ToList();

            return this.eventRepository.Find(id);
        }

        public void Update(Evenement evt)
        {
            this.eventRepository.Update(evt);
        }

        public void Create(Evenement evt, HttpFileCollectionBase files)
        {
            var evtImageRepository = this.eventRepository.CreateRepository<EvenementImage>();
            this.eventRepository.Create(evt);

            for (var i = 0; i < files.Count; i++)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "images", files[i].FileName);
                if(File.UploadHttpFile(files[i], path))
                {
                    var evtImage = new EvenementImage()
                    {
                        Title = files[i].FileName,
                        Path = Path.Combine("/", "Content", "images", files[i].FileName),
                        Evenement = this.eventRepository.Find(evt.Id)
                    };
                    evtImageRepository.Create(evtImage);
                }
            }
        }

        public void Remove(Evenement evt)
        {
            var evtImageRepository = this.eventRepository.CreateRepository<EvenementImage>();

            foreach (var image in evt.Images.ToArray())
            {
                evtImageRepository.Remove(image);
            }

            this.eventRepository.Remove(evt);
        }
        
    }
}
