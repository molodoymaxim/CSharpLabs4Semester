using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace лаба5_6_с_шарп.Controller
{
    public class LoaderController
    {
        public Models.Loaders LoaderControll;
        private int int_startY { get; set; }


        public LoaderController()
        {
            InitializeLoaderController();
            InitLoader();
        }


        public LoaderController(int startY)
        {
            InitializeLoaderController(startY);
            InitLoader();
        }


        public void InitializeLoaderController()
        {
            LoaderControll = new Models.Loaders();
            LoaderControll.LoadBatch = 0;
            LoaderControll.Loading = false;
            int_startY = 0;
        }


        public void InitializeLoaderController(int startY)
        {
            LoaderControll = new Models.Loaders();
            LoaderControll.LoadBatch = 0;
            LoaderControll.Loading = false;
            int_startY = startY;
        }


        public void InitLoader()
        {
            LoaderControll.Loader.PosX = 50;
            LoaderControll.Loader.PosY = 230;
        }

        // Процесс загрузки деталей погрузщиком
        public Models.Parts LoadParts()
        {
            Models.Parts newPart = new();
            newPart.PosX = 325;
            newPart.PosY = int_startY + 35;
            return newPart;
        }

        // Загрузка конвеера погрузщиком
        public void LoadConveyor(Models.Conveyors conveyorControll)
        {
            if (LoaderControll.LoadBatch < Models.Loaders.Batch)
            {
                LoaderControll.Loader.PosX = 130;
                LoaderControll.Loader.PosY = int_startY;
                ++LoaderControll.LoadBatch;
                conveyorControll.Reserve.Push(LoadParts());
            }
            else
            {
                LoaderControll.Loader.PosX = 50;
                LoaderControll.Loader.PosY = 230;
                LoaderControll.LoadBatch = 0;
                LoaderControll.Loading = false;
            }
        }


        public void ControlLoad(Models.Conveyors conveyorControll)
        {
            if (conveyorControll.Reserve.Count == 0 || LoaderControll.Loading == true)
            {
                LoaderControll.Loading = true;
                LoadConveyor(conveyorControll);
            }
        }
    }
}
