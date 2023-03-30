using DNNrocketAPI.Components;
using RocketSystemWrapTemplate.Components;
using Simplisity;
using System;
using System.Collections.Generic;
using System.Text;
using RocketDirectoryAPI;
using RocketDirectoryAPI.Components;

namespace RocketSystemWrapTemplate.API
{
    public partial class StartConnect : DNNrocketAPI.APInterface
    {
        public override Dictionary<string, object> ProcessCommand(string paramCmd, SimplisityInfo systemInfo, SimplisityInfo interfaceInfo, SimplisityInfo postInfo, SimplisityInfo paramInfo, string langRequired = "")
        {
            paramCmd = paramCmd.Replace("rocketsystemwraptemplate_", "rocketdirectoryapi_");
            systemInfo.SetXmlProperty("genxml/systemkey", "rocketsystemwraptemplate");
            var catalogStartConnect = new RocketDirectoryAPI.API.StartConnect();
            return catalogStartConnect.ProcessCommand(paramCmd, systemInfo, interfaceInfo, postInfo, paramInfo, langRequired);
        }
    }

}
