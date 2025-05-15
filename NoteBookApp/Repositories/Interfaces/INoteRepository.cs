using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBookApp.Entities;
using NoteBookApp.Models;


namespace Repositories.Interfaces
{
    public interface INoteRepository
    {
        List<Note> GetAll();//Tüm notları getirir.
        Note GetById(int id);//ID’ye göre getirir.
        void Add(Note note);//Yeni not ekler.
        void Update(Note note);//Notu günceller.
        void Delete(int id);//Notu siler ID ile.
    }
}
