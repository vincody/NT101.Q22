from Crypto.Cipher import DES

def avalanche_test(key_bytes):
    # Đảm bảo key phải đúng 8 bytes cho thuật toán DES
    if len(key_bytes) != 8:
        print(f"Lỗi: Key '{key_bytes}' không đủ 8 bytes. Vui lòng thêm ký tự để đủ 8 bytes.")
        return

    p1 = b'STAYHOME'
    p2 = b'STAYHOMA' # Chỉ khác 1 ký tự cuối (E và A)
    
    # 1. Khởi tạo thuật toán DES chế độ ECB
    cipher = DES.new(key_bytes, DES.MODE_ECB)
    
    # 2. Mã hóa 2 bản rõ
    c1 = cipher.encrypt(p1)
    c2 = cipher.encrypt(p2)
    
    # 3. Chuyển đổi bản mã sang chuỗi nhị phân (64 bit)
    # Dùng format '064b' để đảm bảo luôn đủ 64 bit, không bị cắt mất số 0 ở đầu
    c1_bin = format(int.from_bytes(c1, 'big'), '064b')
    c2_bin = format(int.from_bytes(c2, 'big'), '064b')
    
    # 4. Đếm số bit khác nhau (Tính khoảng cách Hamming)
    diff_bits = 0
    for b1, b2 in zip(c1_bin, c2_bin):
        if b1 != b2:
            diff_bits += 1
            
    # 5. Tính tỷ lệ % bit bị thay đổi
    percent_changed = (diff_bits / 64) * 100
    
    print(f"--- Đang test với Key: {key_bytes} ---")
    print(f"Bản mã 1 (p1): {c1_bin}")
    print(f"Bản mã 2 (p2): {c2_bin}")
    print(f"Số bit khác nhau: {diff_bits}/64")
    print(f"Tỷ lệ thay đổi:   {percent_changed:.2f}%\n")

# Chạy thử nghiệm 1: Key mặc định của đề bài
avalanche_test(b'87654321')

# Chạy thử nghiệm 2: Thay key bằng Mã số sinh viên (MSSV) của bạn
# LƯU Ý: Khóa DES BẮT BUỘC phải dài 8 bytes. 
# Nếu MSSV của bạn (ví dụ 20520000) dài 8 ký tự thì truyền thẳng vào.
# Nếu ngắn hơn, hãy thêm khoảng trắng hoặc số 0 vào cuối cho đủ 8 nhé.
avalanche_test(b'24522019') # Hãy sửa lại thành MSSV của bạn và nhóm bạn!