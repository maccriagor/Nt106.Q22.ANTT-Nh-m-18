# Nt106.Q22.ANTT-Nhóm-18

## Đồ án quản lý quán cà phê do nhóm 18 lớp NT106.Q22.ANTT thực hiện
**Ứng dụng quản lý quán cà phê**
## Danh sách tính năng:
**Tính năng chung:**
- Đăng nhập: Đăng nhập, mã hóa mật khẩu (BCrypt),
- Đăng ký: Đăng ký tài khoản mới (thường do Admin thực hiện hoặc tự đăng ký).
- Quên mật khẩu/sửa mật khẩu: Gửi mã OTP xác thực qua Email (SMTP) để lấy lại mật khẩu.
- Chỉnh sửa thông tin cá nhân
- Chat và gửi thông báo: Hệ thống nhắn tin thời gian thực giữa các nhân viên (Socket TCP) và gửi tin nhắn thông báo đến toàn bộ nhân viên.
**Tính năng quản lý:**
- Quản lý nhân viên: thêm, xóa (Khóa), sửa, xem danh sách và phân quyền tài khoản.
- Quản lý Menu: thêm, xóa, sửa (trạng thái còn hàng/hết hàng), xem thông tin các món.
- Quản lý bàn ăn: thêm, xóa, sửa, xem thông tin bàn ăn realtime.
- Quản lý hóa đơn: Tra cứu, xem lịch sử hóa đơn theo Mã hóa đơn hoặc Mã bàn ăn.
- Quản lý mã giảm giá: thêm, xóa, sửa, xem thông tin mã giảm giá (hệ thống tự động quét và vô hiệu hóa mã hết hạn)
- Thống kê doanh thu: thống kê doanh thu theo thời gian và xuất báo cáo (excel).
**Tính năng nhân viên phục vụ: **
- Quản lý sơ đồ bàn trực quan: Hiển thị màu sắc theo trạng thái: Trống (Xanh), Có khách (Đỏ), Đã đặt (Xám).
- Đặt bàn: Giữ chỗ/đặt bàn trước cho khách.
- Chuyển bàn: Chuyển bàn đang có khách sang bàn trống khác
- Đặt món: tìm kiếm món, thêm vào giỏ hàng sau đó gửi xuống bếp (Realtime)
- Quản lý khách hàng: thêm, xóa, sửa, xem thông tin khách hàng
- Theo dõi tiến độ món: trạng thái từ bếp
- Thanh toán tiền mặt: Xác nhận thanh toán hóa đơn bằng tiền mặt.
- Thanh toán chuyển khoản QR (Sepay): Tạo mã QR VietQR động, tự động xác nhận khi tiền về (Webhook).
- Nhận thông báo món: Nhận Tin nhắn khi bếp báo món đã hoàn thành.
**Tính năng nhân viên bếp: **
- Hiển thị Order:  Danh sách món ăn tự động cập nhật khi có đơn mới.
- Cập nhật trạng thái món: chờ xác nhận → đang chế biến → hoàn thành
- Sắp xếp & Ưu tiên: Sắp xếp món theo thời gian order hoặc độ ưu tiên.Tự động đánh dấu ưu tiên hoặc cảnh báo đỏ đối với các món ăn chờ quá lâu.
- Thống kê hiệu suất: Xem số lượng đơn đã làm, món bán chạy, top đầu bếp, xuất báo cáo hiệu suất theo thời gian
