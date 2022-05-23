using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CuaHangTheThao.Data;
using System;
using System.Linq;

namespace CuaHangTheThao.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CuaHangTheThaoContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CuaHangTheThaoContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.DoTheThao.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }

                context.DoTheThao.AddRange(
                new DoTheThao
                {
                    Title = "Áo Mancity",
                    ReleaseDate = DateTime.Parse("2022-10-16"),
                    Genre = "ss",
                    Price = 11.98M,
                    Rating = "10"
                },
                new DoTheThao
                {
                    Title = "Tất Đá Bóng",
                    ReleaseDate = DateTime.Parse("2021-8-3"),
                    Genre = "S",
                    Price = 18.59M,
                    Rating = "20"
                },
                new DoTheThao
                {
                    Title = "Giay roben ",
                    ReleaseDate = DateTime.Parse("2019-3-20"),
                    Genre = "s",
                    Price = 11.98M,
                    Rating = "10"
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}