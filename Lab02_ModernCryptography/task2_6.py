import sympy
import random
import math

print("=== 1. KIỂM TRA VÀ TẠO SỐ NGUYÊN TỐ ===")

# 1.1 Tạo số nguyên tố 8, 16, 64 bits
def generate_prime(bits):
    # Dải giá trị cho số n-bit là từ 2^(n-1) đến (2^n - 1)
    lower = 2**(bits - 1)
    upper = 2**bits - 1
    return sympy.randprime(lower, upper)

print(f"Số nguyên tố ngẫu nhiên 8-bit : {generate_prime(8)}")
print(f"Số nguyên tố ngẫu nhiên 16-bit: {generate_prime(16)}")
print(f"Số nguyên tố ngẫu nhiên 64-bit: {generate_prime(64)}\n")

# 1.2 Xác định 10 số nguyên tố lớn nhất nhỏ hơn số nguyên tố Mersenne thứ 10
# Số nguyên tố Mersenne có dạng 2^p - 1. Số Mersenne thứ 10 ứng với p = 89
M10 = (2**89) - 1
print(f"Số nguyên tố Mersenne thứ 10 (M10) = {M10}")

primes_before_M10 = []
current = M10
for _ in range(10):
    current = sympy.prevprime(current) # Tìm số nguyên tố liền trước
    primes_before_M10.append(current)

print("10 số nguyên tố lớn nhất nhỏ hơn M10:")
for i, p in enumerate(primes_before_M10, 1):
    print(f"  {i}. {p}")

# 1.3 Kiểm tra một số nguyên tùy ý nhỏ hơn 2^89 - 1
test_num = random.randint(2, M10 - 1)
# Hàm sympy.isprime sử dụng thuật toán Miller-Rabin dưới nền
is_prime = sympy.isprime(test_num)
print(f"\nKiểm tra số ngẫu nhiên: {test_num}")
print(f"Kết quả (Miller-Rabin)  : {'LÀ số nguyên tố' if is_prime else 'KHÔNG phải số nguyên tố'}")


print("\n=== 2. ƯỚC CHUNG LỚN NHẤT (GCD) ===")
# Sử dụng thuật toán Euclid thông qua hàm math.gcd
num1 = random.randint(10**50, 10**60) # Số cực lớn ~ 60 chữ số
num2 = random.randint(10**50, 10**60)
gcd_result = math.gcd(num1, num2)
print(f"Số A: {num1}")
print(f"Số B: {num2}")
print(f"Ước chung lớn nhất GCD(A, B): {gcd_result}")


print("\n=== 3. LŨY THỪA MODULO (MODULAR EXPONENTIATION) ===")
a, x, p = 7, 40, 19
result = pow(a, x, p)
print(f"Ví dụ đề bài: {a}^{x} mod {p} = {result}")

# Thay vì tính 7^40