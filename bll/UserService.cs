using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using bo;

namespace bll
{
    public class UserService
    {
        private UserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public List<Evenement> FindAll()
        {
            return this.userRepository.FindAll();
        }

        public Evenement Find(int id)
        {
            return this.userRepository.Find(id);
        }

        public void Update(Evenement evt)
        {
            this.userRepository.Update(evt);
        }

        public void Create(Evenement evt)
        {
            this.userRepository.Create(evt);
        }

        public void Remove(Evenement evt)
        {
            this.userRepository.Remove(evt);
        }
    }
}
