using CrossSell_App.Models;
using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossSell_App.Manager
{
    public class MetadatasManager
    {
        private MetadataService repo = new MetadataService();
        public List<MetadataTO> GetAllMetadata()
        {
            var data= repo.GetAllMetadata();



            var dataToReturn = data.Select(p => new MetadataTO()
            {
                Metadata_Name = p.Metadata_Name,
                Metadata_Id = p.Metadata_Id,
                IsActive = p.IsActive

            }).ToList();

            return dataToReturn;
        }


        public MetadataTO GetMetadatabyId(int? metadaId)
        {
            var p= repo.GetMetadatabyId(metadaId);
            MetadataTO result = new MetadataTO()
            {
                Metadata_Name = p.Metadata_Name,
                Metadata_Id = p.Metadata_Id,
                IsActive = p.IsActive
            };
            return result;
        }


        public void SaveMetadata(MetadataTO data)
        {
           

            Metadata datatoSave = new Metadata()
            {
                Metadata_Id = data.Metadata_Id,
                Metadata_Name = data.Metadata_Name,
                IsActive = true
            };
            repo.SaveMetadata(datatoSave);


            //try
            //{
            //    db.Metadatas.Add(datatoSave);
            //    db.SaveChanges();
            //}
            //catch(Exception ex)
            //{

            //}
        }

        public void UpdateMetadata(MetadataTO metadata)
        {
            Metadata dataToupdate = new Metadata()
            {
                Metadata_Id =metadata.Metadata_Id,
                Metadata_Name = metadata.Metadata_Name,
                IsActive = metadata.IsActive
            };
        repo.UpdateMetadata(dataToupdate);
            //try
            //{
            //    dataToupdate.Metadata_Name = metadata.Metadata_Name;
            //    dataToupdate.IsActive = metadata.IsActive;


            //    db.SaveChanges();
            //}
            //catch(Exception ex)
            //{

            //}
        }

        public void DeleteMetadata(int id)
        {
            repo.DeleteMetadata(id);
            
        }

        //private bool disposed = false;
        //public void Dispose(bool disposing)
        //{
        //    if (!this.disposed)

        //    {

        //        if (disposing)

        //        {

        //            db.Dispose();

        //        }

        //    }

        //    this.disposed = true;
        //}
        //public void Dispose()

        //{

        //    Dispose(true);

        //    GC.SuppressFinalize(this);

        //}
    }
}
