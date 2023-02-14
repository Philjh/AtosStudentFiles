using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceProject.DUKW
{
    public class AmphibiousVehicle : ILandVehicle, IWaterVehicle
    {
        public void Brake()
        {
            
        }

        void IWaterVehicle.Brake()
        {
           
        }
    }
}
