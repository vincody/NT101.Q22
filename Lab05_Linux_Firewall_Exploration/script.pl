#!/usr/bin/perl -w
use strict; 
use warnings;

# Yêu cầu Perl nhả kết quả ngay lập tức
select STDOUT; 
$| = 1;

while (<>)
{
    my @parts = split;    
    my $url = $parts[0];
    
    # 1. Kiểm tra URL có chứa đuôi hình ảnh phổ biến không (không phân biệt hoa thường nhờ chữ 'i')
    # 2. VÀ URL đó KHÔNG được chứa domain 'citypng.com' để tránh vòng lặp vô tận
    if ($url =~ /\.(jpg|jpeg|png|gif|bmp|webp)/i && $url !~ /citypng\.com/)
    {
        # Chuyển hướng mọi hình ảnh sang link của bạn (giữ nguyên http)
        print "http://www.citypng.com/public/uploads/preview/hd-white-stop-hand-sign-on-red-stop-highway-sign-png-704081695134723ymfy3wotoi.png\n";
    }    
    else
    {
        # Các file khác (html, css, js...) thì cho qua bình thường
        print "\n";
    }
}
