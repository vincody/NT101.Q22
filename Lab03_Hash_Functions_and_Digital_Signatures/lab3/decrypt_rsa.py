import base64

def decrypt(c, d, n):
    return pow(c, d, n)

# Bộ khóa 1 (từ p1, q1, e1)
n1 = 187
d1 = 23

# Bộ khóa 2 (từ p2, q2, e2) - Bạn hãy lấy giá trị d2, n2 đã tính ở bước trước
n2 = 13588494884241604927236540679708761008064972584191  # p2 * q2
d2 = 11190525203494262875371268688461803117465271531217  # pow(17, -1, phi2)

# Bộ khóa 3 (từ p3, q3, e3) - Hệ Hex
n3 = 0xE10B3... # p3 * q3 (Tính bằng hex)
d3 = 0x...      # pow(e3, -1, phi3)

# Hàm chuyển từ số nguyên sang chuỗi văn bản (nếu bản rõ là text)
def int_to_str(n):
    try:
        return n.to_bytes((n.bit_length() + 7) // 8, 'big').decode()
    except:
        return str(n)

# Ví dụ giải mã bản mã số 2 (Dạng Hex)
c2_hex = "C87F570FC4F699CEC24020C6F54221ABAB2CE0C3"
c2_int = int(c2_hex, 16)
print(f"Kết quả thử khóa 2: {int_to_str(decrypt(c2_int, d2, n2))}")
