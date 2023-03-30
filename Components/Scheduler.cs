﻿using System;
using System.Collections.Generic;
using System.Text;
using DNNrocketAPI;
using DNNrocketAPI.Components;
using RocketDirectoryAPI.Components;
using Simplisity;

namespace RocketSystemWrapTemplate.Components
{
    public class Scheduler : SchedulerInterface
    {
        /// <summary>
        /// This is called by DNNrocketAPI.Components.RocketScheduler
        /// </summary>
        /// <param name="systemData"></param>
        /// <param name="rocketInterface"></param>
        public override void DoWork()
        {
            var portalList = PortalUtils.GetPortals();
            foreach (var portalId in portalList)
            {
                var portalCatalog = new PortalCatalogLimpet(portalId, DNNrocketUtils.GetCurrentCulture(), "rocketsystemwraptemplate");

                if (portalCatalog.Active && (portalCatalog.SchedulerRunHours == 0 || (portalCatalog.LastSchedulerTime < DateTime.Now.AddHours(portalCatalog.SchedulerRunHours * -1))))
                {

                    portalCatalog.LastSchedulerTime = DateTime.Now;
                    portalCatalog.Update();
                }
                else
                {
                    if (portalCatalog.DebugMode) LogUtils.LogSystem("RocketSystemWrapTemplate Scheduler not run, LastSchedulerTime: " + portalCatalog.LastSchedulerTime.ToString("O") + " CurrentTime: " + DateTime.Now.ToString("O"));
                }
            }
        }
    }
}