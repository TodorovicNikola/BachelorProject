CREATE TRIGGER TRIG_UPDATE_MATERIAL
ON DodelaMaterijala
AFTER INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON;


	DECLARE @ACTION as char(1) = 'I'; --INSERT JE PODRAZUMEVANA AKCIJA

	DECLARE @POTREBA_MATERIJALA_ID INT
	DECLARE @MATERIJAL_ID INT
	DECLARE @DODELJENA_KOLICINA FLOAT

	-----------------------------------------------------ODABIR AKCIJE-----------------------------------------------------
    IF EXISTS(SELECT * FROM DELETED)
    BEGIN
        SET @ACTION = 
            CASE
                WHEN EXISTS(SELECT * FROM INSERTED) THEN 'U' --POSTAVLJANJE NA UPDATE.
                ELSE 'D' -- POSTAVLJANJE DA DELETE.       
            END
    END
    ELSE 
        IF NOT EXISTS(SELECT * FROM INSERTED) RETURN; -- NISTA SE NIJE INSERTOVALO, NITI UPDATEOVALO.

	
	---------------------------------------------------------INSERT---------------------------------------------------------
	IF(@ACTION LIKE 'I')
	BEGIN
		SELECT * INTO #TEMP_INSERTED FROM inserted;

		WHILE(EXISTS(SELECT PotrebaMaterijalaID from #TEMP_INSERTED))
		BEGIN
			SELECT TOP 1 @POTREBA_MATERIJALA_ID= PotrebaMaterijalaID, @DODELJENA_KOLICINA=DodMatKolicina FROM #TEMP_INSERTED;

			UPDATE PotrebaMaterijala
			SET PotrMatKolicina = PotrMatKolicina - @DODELJENA_KOLICINA
			WHERE PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			SELECT @MATERIJAL_ID=MaterijalID from PotrebaMaterijala where PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			UPDATE Materijal
			SET MaterijalRaspolozivaKolicina = MaterijalRaspolozivaKolicina - @DODELJENA_KOLICINA
			WHERE MaterijalID = @MATERIJAL_ID;

			DELETE TOP (1) FROM #TEMP_INSERTED;
		END

	END

	-----------------------------------------------------------DELETE-------------------------------------------------------
	IF(@ACTION LIKE 'D')
	BEGIN
		SELECT * INTO #TEMP_DELETED FROM deleted;

		WHILE(EXISTS(SELECT PotrebaMaterijalaID from #TEMP_DELETED))
		BEGIN
			SELECT TOP 1 @POTREBA_MATERIJALA_ID= PotrebaMaterijalaID, @DODELJENA_KOLICINA=DodMatKolicina FROM #TEMP_DELETED;

			UPDATE PotrebaMaterijala
			SET PotrMatKolicina = PotrMatKolicina + @DODELJENA_KOLICINA
			WHERE PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			SELECT @MATERIJAL_ID=MaterijalID from PotrebaMaterijala where PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			UPDATE Materijal
			SET MaterijalRaspolozivaKolicina = MaterijalRaspolozivaKolicina + @DODELJENA_KOLICINA
			WHERE MaterijalID = @MATERIJAL_ID;

			DELETE TOP (1) FROM #TEMP_DELETED;	
		END
	END


	-------------------------------------------------------------UPDATE-----------------------------------------------------
	IF(@ACTION LIKE 'U')
	BEGIN

		----------------------------------------------------DEO ZA BRISANJE-------------------------------------------------
		SELECT * INTO #TEMP_DELETED_UPDATE FROM deleted;

		WHILE(EXISTS(SELECT PotrebaMaterijalaID from #TEMP_DELETED_UPDATE))
		BEGIN
			SELECT TOP 1 @POTREBA_MATERIJALA_ID= PotrebaMaterijalaID, @DODELJENA_KOLICINA=DodMatKolicina FROM #TEMP_DELETED_UPDATE;

			UPDATE PotrebaMaterijala
			SET PotrMatKolicina = PotrMatKolicina + @DODELJENA_KOLICINA
			WHERE PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			SELECT @MATERIJAL_ID=MaterijalID from PotrebaMaterijala where PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			UPDATE Materijal
			SET MaterijalRaspolozivaKolicina = MaterijalRaspolozivaKolicina + @DODELJENA_KOLICINA
			WHERE MaterijalID = @MATERIJAL_ID;

			DELETE TOP (1) FROM #TEMP_DELETED_UPDATE;	
		END


		------------------------------------------------------DEO ZA UPIS----------------------------------------------------
		SELECT * INTO #TEMP_INSERTED_UPDATE FROM inserted;

		WHILE(EXISTS(SELECT PotrebaMaterijalaID from #TEMP_INSERTED_UPDATE))
		BEGIN
			SELECT TOP 1 @POTREBA_MATERIJALA_ID= PotrebaMaterijalaID, @DODELJENA_KOLICINA=DodMatKolicina FROM #TEMP_INSERTED_UPDATE;

			UPDATE PotrebaMaterijala
			SET PotrMatKolicina = PotrMatKolicina - @DODELJENA_KOLICINA
			WHERE PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			SELECT @MATERIJAL_ID=MaterijalID from PotrebaMaterijala where PotrebaMaterijalaID = @POTREBA_MATERIJALA_ID;

			UPDATE Materijal
			SET MaterijalRaspolozivaKolicina = MaterijalRaspolozivaKolicina - @DODELJENA_KOLICINA
			WHERE MaterijalID = @MATERIJAL_ID;

			DELETE TOP (1) FROM #TEMP_INSERTED_UPDATE;
		END

	END
END

