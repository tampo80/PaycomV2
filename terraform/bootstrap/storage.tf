resource "aws_s3_bucket" "s3_bucket" {
  bucket = "paycom-terraform-backend"
  tags = {
    Name    = "paycom-terraform-backend"
    Project = "paycom"
  }
  lifecycle {
    prevent_destroy = true
  }
}
