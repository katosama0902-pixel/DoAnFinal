using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnFinal.DAL
{
    public class MovieDAL
    {
        private CinemaModel db = new CinemaModel();

        // 1. Lấy toàn bộ danh sách phim (trừ phim đã xóa mềm nếu có)
        public List<movie> GetAllMovies()
        {
            // Lấy tất cả phim, sắp xếp phim mới nhất lên đầu
            return db.movies.OrderByDescending(m => m.created_at).ToList();
        }

        // 2. Tìm kiếm phim theo tên
        public List<movie> SearchMovies(string keyword)
        {
            return db.movies.Where(m => m.movie_name.Contains(keyword)).ToList();
        }

        // 3. Xóa phim (Thực chất là cập nhật Status = 'Stopped')
        // Chúng ta hạn chế xóa cứng để giữ lịch sử bán vé
        public bool DeleteMovie(int id)
        {
            var movie = db.movies.Find(id);
            if (movie != null)
            {
                movie.status = "Stopped"; // Ngừng chiếu
                                          // Hoặc nếu muốn xóa hẳn: db.movies.Remove(movie);

                db.SaveChanges();
                return true;
            }
            return false;
        }

        // 4. Lấy phim theo ID (Dùng cho chức năng Sửa sau này)
        public movie GetMovieById(int id)
        {
            return db.movies.Find(id);
        }

        // 5. Thêm phim mới
        public void AddMovie(movie mv)
        {
            db.movies.Add(mv);
            db.SaveChanges();
        }

        // 6. Cập nhật phim
        public void UpdateMovie(movie mv)
        {
            var existingMovie = db.movies.Find(mv.id);
            if (existingMovie != null)
            {
                existingMovie.movie_id = mv.movie_id;
                existingMovie.movie_name = mv.movie_name;
                existingMovie.genre = mv.genre;
                existingMovie.price = mv.price;
                existingMovie.capacity = mv.capacity;
                existingMovie.status = mv.status;

                // Chỉ cập nhật ảnh nếu người dùng có chọn ảnh mới (ảnh khác null)
                if (!string.IsNullOrEmpty(mv.movie_image))
                {
                    existingMovie.movie_image = mv.movie_image;
                }

                existingMovie.updated_at = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}