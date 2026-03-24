from Crypto.Cipher import AES

# Khóa 16 bytes (128 bits)
key = b'1234567890123456'

# Bản rõ 32 bytes gồm 2 khối 16 bytes giống hệt nhau
plaintext = b"UIT_LAB_UIT_LAB_UIT_LAB_UIT_LAB_"

print("--- THÔNG TIN ĐẦU VÀO ---")
print(f"Block 1: {plaintext[:16]}")
print(f"Block 2: {plaintext[16:]}\n")

# 1. Chế độ AES-ECB
cipher_ecb = AES.new(key, AES.MODE_ECB)
ct_ecb = cipher_ecb.encrypt(plaintext)

# 2. Chế độ AES-CBC
# Cần thêm Vector khởi tạo (IV) độ dài 16 bytes
iv = b'0000000000000000' 
cipher_cbc = AES.new(key, AES.MODE_CBC, iv)
ct_cbc = cipher_cbc.encrypt(plaintext)

# Hàm phụ để in format 2 khối rõ ràng (32 ký tự hex = 16 bytes)
def print_blocks(ct_hex):
    return f"Block 1: {ct_hex[:32]}\nBlock 2: {ct_hex[32:]}"

print("--- KẾT QUẢ MÃ HÓA AES-ECB ---")
print(print_blocks(ct_ecb.hex()))
print()

print("--- KẾT QUẢ MÃ HÓA AES-CBC ---")
print(print_blocks(ct_cbc.hex()))