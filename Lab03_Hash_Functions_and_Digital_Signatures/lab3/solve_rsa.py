import base64

def calculate_d(e, p, q):
    return pow(e, -1, (p - 1) * (q - 1))

p1, q1, e1 = 11, 17, 7
n1, d1 = p1 * q1, calculate_d(e1, p1, q1)
p2, q2, e2 = 20079993872842322116151219, 676717145751736242170789, 17
n2, d2 = p2 * q2, calculate_d(e2, p2, q2)
p3 = int("F7E75FDC469067FFDC4E847C51F452DF", 16)
q3 = int("E85CED54AF57E53E092113E62F436F4F", 16)
e3 = int("0D88C3", 16)
n3, d3 = p3 * q3, calculate_d(e3, p3, q3)

keys = {
    "Key1 (n=187)":        (e1, d1, n1),
    "Key2 (thập phân)":    (e2, d2, n2),
    "Key3 (hex)":          (e3, d3, n3),
}

def try_decode(m_bytes):
    """Trả về text nếu đọc được, ngược lại trả về hex"""
    cleaned = m_bytes.replace(b'\x00', b'')
    try:
        text = cleaned.decode('utf-8')
        if any(c.isalpha() for c in text):
            return text
    except:
        pass
    # Fallback: trả về printable Latin-1
    latin = cleaned.decode('latin-1')
    printable = ''.join(c for c in latin if 32 <= ord(c) < 127)
    if len(printable) >= 3:
        return f"[printable] {printable}"
    return f"[hex] {m_bytes.hex()}"

def crack_rsa(cipher_bytes, label):
    print(f"\n{'='*65}")
    print(f"  {label}  ({len(cipher_bytes)} bytes)")
    print('='*65)

    for key_name, (e, d, n) in keys.items():
        n_len = (n.bit_length() + 7) // 8

        for mode_name, kval in [("Bảo mật (dùng d)", d), ("Xác thực (dùng e)", e)]:

            # --- PHƯƠNG PHÁP 1: NGUYÊN KHỐI ---
            c_int = int.from_bytes(cipher_bytes, 'big')
            if c_int < n:
                m_int = pow(c_int, kval, n)
                m_bytes = m_int.to_bytes((m_int.bit_length() + 7) // 8, 'big') if m_int else b'\x00'
                result = try_decode(m_bytes)
                if result:
                    print(f"[+] {key_name} | {mode_name} | Nguyên khối")
                    print(f"    => {result}")

            # --- PHƯƠNG PHÁP 2: CHIA KHỐI ---
            if len(cipher_bytes) % n_len == 0 and len(cipher_bytes) > n_len:
                decrypted = b""
                for i in range(0, len(cipher_bytes), n_len):
                    blk = cipher_bytes[i:i+n_len]
                    m = pow(int.from_bytes(blk, 'big'), kval, n)
                    decrypted += (m.to_bytes((m.bit_length()+7)//8, 'big') if m else b'\x00')
                result = try_decode(decrypted)
                if result:
                    print(f"[+] {key_name} | {mode_name} | Chia khối {n_len}B")
                    print(f"    => {result}")

            # --- PHƯƠNG PHÁP 3: TỪNG BYTE (chỉ key1) ---
            if n == 187 and all(b < n for b in cipher_bytes):
                text = ''.join(chr(pow(b, kval, n)) for b in cipher_bytes)
                printable = ''.join(c for c in text if c.isprintable())
                if len(printable) > 5 and any(c.isalpha() for c in printable):
                    print(f"[+] {key_name} | {mode_name} | Từng byte")
                    print(f"    => {printable}")

# ===============================
s1 = "raUcesUlOkx/8ZhgodMoo0Uu18sC20yXlQFevSu7W/FDxIy0YRHMyXcHdD9PBvIT2aUft5fCQEGomiVVPv4I"
s2 = "C87F570FC4F699CEC24020C6F54221ABAB2CE0C3"
s3 = "Z2BUSkJcg0w4XEpgm0JcMExEQmBlVH6dYEpNTHpMHptMQ7NgTHlgQrNMQ2BKTQ=="
s4 = ("001010000001010011111111101101110010111011001010111011000110011"
      "110111111001111110110100011001111001100001001010001010100111101"
      "010100110011101110111011110101101100000100")

crack_rsa(base64.b64decode(s1), "Chuỗi 1 (Base64)")
crack_rsa(bytes.fromhex(s2), "Chuỗi 2 (Hex)")
crack_rsa(base64.b64decode(s3), "Chuỗi 3 (Base64)")
crack_rsa(int(s4, 2).to_bytes((len(s4)+7)//8, 'big'), "Chuỗi 4 (Binary)")
