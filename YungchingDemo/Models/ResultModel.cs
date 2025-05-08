namespace YungchingDemo.Models
{
    public class ComboBoxModel
    {
        public string CODEID { get; set; }
        public string CODENAME { get; set; }
    }
    public class ResultModel
    {
        /// <summary> 專案編號 </summary>
        public string ProjectID { get; set; } = "";
        /// <summary> 專案名稱 </summary>
        public string ProjectName { get; set; } = "";
        /// <summary> 房屋種類 </summary>
        public string Type { get; set; } = "";
        /// <summary> 房屋地址 </summary>
        public string Address { get; set; } = "";
        /// <summary> 房屋價錢(萬) </summary>
        public int Price { get; set; } = 0;
        /// <summary> 房屋坪數 </summary>
        public decimal Square { get; set; } = 0;
        /// <summary> 公設比 </summary>
        public int PublicRatio { get; set; } = 0;
        /// <summary> 是否附停車位 </summary>
        public string HaveSpace { get; set; } = "";
        /// <summary> 備註 </summary>
        public string Remark { get; set; } = "";
    }
}
