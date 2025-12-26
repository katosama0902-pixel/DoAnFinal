using DAL;
using DoAnFinal.DAL;
using System.Collections.Generic;

namespace DoAnFinal.BLL
{
    public class MovieBLL
    {
        private MovieDAL movieDAL = new MovieDAL();

        public List<movie> GetMovieList()
        {
            return movieDAL.GetAllMovies();
        }

        public List<movie> SearchMovie(string keyword)
        {
            return movieDAL.SearchMovies(keyword);
        }

        public bool DeleteMovie(int id)
        {
            // Có thể thêm logic kiểm tra: Nếu phim đang có người đặt vé thì không cho xóa
            return movieDAL.DeleteMovie(id);
        }

        public movie GetMovieById(int id)
        {
            return movieDAL.GetMovieById(id);
        }

        public void AddMovie(movie mv)
        {
            // Có thể thêm validate logic ở đây (VD: check giá tiền < 0)
            movieDAL.AddMovie(mv);
        }

        public void UpdateMovie(movie mv)
        {
            movieDAL.UpdateMovie(mv);
        }
    }
}