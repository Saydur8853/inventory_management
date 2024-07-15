create table tb_Category(
cate_id number,
cate_name varchar2 (30)
);

select * from tb_Category;

CREATE TABLE tb_UOM (
    uom_id NUMBER ,
    uom_name VARCHAR2(10)
);
CREATE TABLE tb_Product(
    prod_id Number,
    prod_code VARCHAR2(20),
    prod_name VARCHAR2(50),
    cate_id number,
    uom_id NUMBER,
    is_active char
    );
    
CREATE TABLE tb_Stock_In (
    po_date DATE,
    prod_id Number,
    po_rate number,
    po_quantity number,
    batch_no varchar2(10)
);

CREATE TABLE tb_Stock_Out (
    del_date DATE,
    prod_id Number,
    del_quantity number
);