from Crypto.Cipher import AES
from Crypto.Util.Padding import pad

# 1. Tạo dữ liệu 1000 byte (sử dụng ký tự 'A' để dễ quan sát)
plaintext = b'A' * 1000
# Đệm dữ liệu để chia hết cho 16 (AES block size). Kết quả sẽ là 1008 bytes (63 khối)
padded_plaintext = pad(plaintext, AES.block_size) 

key = b'1234567890123456'
iv = b'1234567890123456'

# Danh sách các chế độ cần kiểm tra
modes = {
    'ECB': (AES.MODE_ECB, False),
    'CBC': (AES.MODE_CBC, True),
    'CFB': (AES.MODE_CFB, True),
    'OFB': (AES.MODE_OFB, True)
}

print("--- KIỂM TRA SỰ LAN TRUYỀN LỖI (ERROR PROPAGATION) ---")

for mode_name, (mode_val, use_iv) in modes.items():
    # 2. Mã hóa dữ liệu bằng AES-128
    if use_iv:
        # Với CFB, set segment_size=128 để hoạt động theo chuẩn Block cipher 16-byte
        if mode_name == 'CFB':
            cipher = AES.new(key, mode_val, iv, segment_size=128)
        else:
            cipher = AES.new(key, mode_val, iv)
    else:
        cipher = AES.new(key, mode_val)
        
    ciphertext = bytearray(cipher.encrypt(padded_plaintext))
    
    # 3. Làm hỏng bản mã: Đảo 1 bit tại byte thứ 26
    # Vì byte đếm từ 1, byte thứ 26 nằm ở index 25. 
    # Byte 26 nằm gọn trong Khối số 2 (Khối 1: byte 1-16, Khối 2: byte 17-32)
    ciphertext[25] ^= 0x01 
    
    # 4. Giải mã bản mã đã bị hỏng
    if use_iv:
        if mode_name == 'CFB':
            dec_cipher = AES.new(key, mode_val, iv, segment_size=128)
        else:
            dec_cipher = AES.new(key, mode_val, iv)
    else:
        dec_cipher = AES.new(key, mode_val)
        
    decrypted = dec_cipher.decrypt(bytes(ciphertext))
    
    # 5. Quan sát xem có bao nhiêu khối bị hỏng
    corrupted_blocks = []
    # Tổng số khối = 1008 / 16 = 63 khối
    for i in range(len(padded_plaintext) // AES.block_size):
        start = i * AES.block_size
        end = start + AES.block_size
        
        # So sánh từng khối giải mã với khối gốc ban đầu
        if decrypted[start:end] != padded_plaintext[start:end]:
            corrupted_blocks.append(i + 1) # Cộng 1 để in ra Khối 1, Khối 2... dễ hiểu
            
    print(f"Chế độ {mode_name:3}: Các khối bị hỏng là Khối {corrupted_blocks}")