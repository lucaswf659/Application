using Application.Data;
using Application.Models;
using System;
using System.Collections.Generic;

namespace Application.Business
{
    public class ApplicationBusiness
    {
        static public List<ApplicationModel> GetData()
        {
            return ApplicationData.GetApplicationData();
        }

        static public ApplicationModel GetDataById(int id)
        {
            return ApplicationData.GetApplicationDataById(id);
        }

        static public bool SaveData(ApplicationModel appModel)
        {
            return ApplicationData.SaveData(appModel);
        }

        static public bool UpdateData(ApplicationModel appModel)
        {
            return ApplicationData.UpdateData(appModel);
        }

        static public bool DeleteData(int id)
        {
            return ApplicationData.DeleteData(id);
        }
    }
}
