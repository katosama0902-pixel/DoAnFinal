namespace DoAnFinal.DAL
{
    using System;
    using System.Collections.Generic;

    public partial class food_bill
    {
        public int id { get; set; }
        public Nullable<int> staff_id { get; set; }
        public Nullable<int> total_money { get; set; }
        public string items_detail { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
    }
}