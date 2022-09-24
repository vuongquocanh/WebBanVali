using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanVali.Models
{
	[MetadataTypeAttribute(typeof(TDanhMucSPMetadata))]
	public partial class tDanhMucSP
	{
		internal sealed class TDanhMucSPMetadata
		{
			[DisplayName("Mã sản phẩm")]
			[Required(ErrorMessage = "Vui lòng nhập mã sản phẩm!")]
			public string MaSP { get; set; }

			[DisplayName("Tên sản phẩm")]
			public string TenSP { get; set; }

			[DisplayName("Mã chất liệu")]
			public string MaChatLieu { get; set; }

			[DisplayName("Ngăn laptop")]
			public string NganLapTop { get; set; }

			[DisplayName("Model")]
			public string Model { get; set; }

			[DisplayName("Màu sắc")]
			public string MauSac { get; set; }

			[DisplayName("Mã kích thước")]
			public string MaKichThuoc { get; set; }

			[DisplayName("Cân nặng")]
			public Nullable<double> CanNang { get; set; }

			[DisplayName("Độ nổi")]
			public Nullable<double> DoNoi { get; set; }

			[DisplayName("Mã hãng sản xuất")]
			public string MaHangSX { get; set; }

			[DisplayName("Mã nước sản xuất")]
			public string MaNuocSX { get; set; }

			[DisplayName("Mã đặc tính")]
			public string MaDacTinh { get; set; }

			[DisplayName("Website")]
			public string Website { get; set; }

			[DisplayName("Thời gian bảo hành")]
			public Nullable<double> ThoiGianBaoHanh { get; set; }

			[DisplayName("Giới thiệu")]
			public string GioiThieuSP { get; set; }

			[DisplayName("Giá")]
			public Nullable<double> Gia { get; set; }

			[DisplayName("Chiết khấu")]
			public Nullable<double> ChietKhau { get; set; }

			[DisplayName("Mã loại")]
			public string MaLoai { get; set; }

			[DisplayName("Mã đối tượng")]
			public string MaDT { get; set; }

			[DisplayName("Ảnh")]
			public string Anh { get; set; }
			
        }
	}
}