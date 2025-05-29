terraform {
  backend "s3" {
    bucket         = "paycom-terraform-backend"
    key            = "paycom/dev/terraform.tfstate"
    region         = "us-east-1"
    dynamodb_table = "paycom-state-locks"
  }
}
