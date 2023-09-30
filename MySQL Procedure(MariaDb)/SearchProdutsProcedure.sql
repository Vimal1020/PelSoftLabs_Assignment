DELIMITER //
DROP PROCEDURE IF EXISTS SearchProducts;
CREATE PROCEDURE SearchProducts(
    IN p_ProductName VARCHAR(255),
    IN p_Size VARCHAR(255),
    IN p_Price DECIMAL(10,2),
    IN p_MfgDate DATE,
    IN p_Category VARCHAR(255),
    IN p_Conjunction VARCHAR(3)
)
BEGIN
    SET @sqlQuery = 'SELECT * FROM tbl_Product WHERE 1=1 ';

    IF p_ProductName IS NOT NULL AND p_ProductName <> '' THEN
        SET @sqlQuery = CONCAT(@sqlQuery, p_Conjunction, ' ProductName LIKE ''%', p_ProductName, '%'' ');
    END IF;

    IF p_Size IS NOT NULL AND p_Size <> '' THEN
        SET @sqlQuery = CONCAT(@sqlQuery, p_Conjunction, ' Size LIKE ''%', p_Size, '%'' ');
    END IF;

    IF p_Price IS NOT NULL THEN
        SET @sqlQuery = CONCAT(@sqlQuery, p_Conjunction, ' Price = ', p_Price, ' ');
    END IF;

    IF p_MfgDate IS NOT NULL THEN
        SET @sqlQuery = CONCAT(@sqlQuery, p_Conjunction, ' MfgDate = ''', p_MfgDate, ''' ');
    END IF;

    IF p_Category IS NOT NULL AND p_Category <> '' THEN
        SET @sqlQuery = CONCAT(@sqlQuery, p_Conjunction, ' Category LIKE ''%', p_Category, '%'' ');
    END IF;

    PREPARE stmt FROM @sqlQuery;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //

DELIMITER ;