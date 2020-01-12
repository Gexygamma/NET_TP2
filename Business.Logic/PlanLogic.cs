using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic
    {
        private PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}
