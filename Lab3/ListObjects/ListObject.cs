using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeansTranporation;

namespace ListObjects
{
    public class ListObject: IObject
    {
        List<TransportVehicle> object_;

        public ListObject()
        {
            object_ = new List<TransportVehicle>();
        }

        public TransportVehicle Get(int id)
        {
            var item=object_.FirstOrDefault(elem=>elem.Id==id);
            if (item==null)
                throw new ArgumentException("Not found Id!");

            return item;
        }

        public IEnumerable<TransportVehicle> GetAll()
        {
            return object_;
        }

        public void Delete(int id)
        {
            var itemToDel=Get(id);
            object_.Remove(itemToDel);
        }

        public void Update(TransportVehicle item)
        {
            var itemToUpd=Get(item.Id);
            itemToUpd.Copy(itemToUpd);
        }

        public void Add(TransportVehicle item)
        {
            if (object_.Count==0)
                item.Id=1;
            else
                item.Id=object_.Max(elem => elem.Id)+1;
            object_.Add(item);
        }
    }
}
