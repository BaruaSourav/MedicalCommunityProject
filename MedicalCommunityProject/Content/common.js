
	 	$('#crossModal').on('show.bs.modal', function(e) {
	 		$(this).find('.confm').innerHtml=$(e.relatedTarget).data('href');

            $(this).find('.btn-ok').attr('href', $(e.relatedTarget).data('href'));
        });
       $("a[data-target=#myPosterModal]").click(function(e) {
			e.preventDefault();
			var target = $(this).attr("href");

			// load the url and show modal on success
			$("#myPosterModal.modal-body").load(target, function() { 
				 $("#myPosterModal").modal("show"); 
			});
		});
	 
		 $(function(){
			$(".searchInternal").keyup(function() //class name of input
			{ 
				var searchid = $('#searchInternal').val();
				var dataString = 'search='+ searchid; // search in post method
				if(searchid !='')
				{
					$.ajax({
					type: "POST",
					url: "<?php echo site_url('search_book/internal_book_search') ?>",
					data: dataString,
					cache: false,
					success: function(html)
					{
					$("#gallary").html(html).show();
					}
					});
				}
				else{
					$.ajax({
					type: "POST",
					url: "<?php echo site_url('search_book/internal_book_search') ?>",
					data: dataString,
					cache: false,
					success: function(html)
					{
					$("#gallary").html(html).show();
					}
					});
				}
				return false;    
			});
		});
    
		//var hellox; 
		function edit_book(bookID)
		{
			//var hellox = bookID;
			save_method = 'update';
			$('#form')[0].reset(); // reset form on modals
			$('.form-group').removeClass('has-error'); // clear error class
			$('.help-block').empty(); // clear error string

			//Ajax Load data from ajax
			$.ajax({
			url : "<?php echo site_url('user_dash/ajax_edit')?>/" + bookID,
			type: "GET",
			dataType: "JSON",
			success: function(data)
			{
				//alert('i am in ' + hellox);
				$('[name="bookID"]').val(data.bookID);
				$('[name="bookName"]').val(data.bookName);
				$('[name="authorName"]').val(data.authorName);
				$('[name="category"]').val(data.category);
				$('[name="description"]').val(data.description);
				$('[name="isLendable"]').val(data.isLendable);
				$('[name="isPurchasable"]').val(data.isPurchasable);
				$('[name="showBooks"]').val(data.showBooks);
				$('[name="lendablePrice"]').val(data.isLendablePrice);
				$('[name="buyablePrice"]').val(data.isBuyablePrice);
				$('#editModal').modal('show'); // show bootstrap modal when complete loaded
				$('.modal-title').text('Edit Book'); // Set title to Bootstrap modal title
			},
			error: function (jqXHR, textStatus, errorThrown)
			{
				alert('Error get data from ajax ' + bookID);
			}
		});
	}
	function save(id){
		$('#btnSave').text('saving...'); //change button text
		$('#btnSave').attr('disabled',true); //set button disable 
		var url;

    if(save_method == 'add') {
        //url = "<?php echo site_url('person/ajax_add')?>";
    } else {
        url = "<?php echo site_url('user_dash/ajax_update')?>";
    }

    // ajax adding data to database
    $.ajax({
        url : url,
        type: "POST",
        data: $('#form').serialize(),
        dataType: "JSON",
        success: function(data)
        {

            if(data.status) //if success close modal and reload ajax table
            {
                $('#editModal').modal('hide');
                location.reload();
            }
            else
            {
                for (var i = 0; i < data.inputerror.length; i++) 
                {
                    $('[name="'+data.inputerror[i]+'"]').parent().parent().addClass('has-error'); //select parent twice to select div form-group class and add has-error class
                    $('[name="'+data.inputerror[i]+'"]').next().text(data.error_string[i]); //select span help-block class set text error string
                }
            }
            $('#btnSave').text('save'); //change button text
            $('#btnSave').attr('disabled',false); //set button enable 


        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            alert('Error adding / update data '+id);
            $('#btnSave').text('save'); //change button text
            $('#btnSave').attr('disabled',false); //set button enable 
        }
    });
	}
	
		function savePoster(){
			 var data = new FormData($('#forms')[0]);
			  $.ajax({
               type:"POST",
               url:"<?php echo site_url('user_dash/book_cover_edit');?>",
               data:data,
               mimeType: "multipart/form-data",
                contentType: false,
                cache: false,
                processData: false,
               success:function(data)
              {
                    $('#myPosterModal').modal('hide');
					location.reload();
 
               }
       });
		}
		function edit_poster(bookid){
			$('#forms')[0].reset(); // reset form on modals
			$('.form-group').removeClass('has-error'); // clear error class
			$('.help-block').empty(); // clear error string
			
			$.ajax({
			url : "<?php echo site_url('user_dash/ajax_edit')?>/" + bookid,
			type: "GET",
			dataType: "JSON",
			success: function(data)
			{
				//alert('i am in ' + data);
				$('[name="bookID"]').val(data.bookID);
				$('[name="coverImg"]').val(data.coverImg);
				$('#myPosterModal').modal('show'); // show bootstrap modal when complete loaded
				$('.modal-title').text('Edit Poster'); // Set title to Bootstrap modal title
			},
			error: function (jqXHR, textStatus, errorThrown)
			{
				alert('Error get data from ajax ' + bookid);
			}
		});
		}

		function saveProfile(){
			var data = new FormData($('#formss')[0]);
			$.ajax({
				type:"POST",
				url:"<?php echo site_url('user_dash/profile_cover_edit');?>",
				data:data,
				mimeType: "multipart/form-data",
                contentType: false,
                cache: false,
                processData: false,
				success:function(data)
				{
                    $('#myProfileModal').modal('hide');
					location.reload();
				}
			});
		}
		function savePages(){
			var data = new FormData($('#pagesform')[0]);
			$.ajax({
				type:"POST",
				url:"<?php echo site_url('reg_book/add_pages');?>",
				data:data,
				mimeType: "multipart/form-data",
                contentType: false,
                cache: false,
                processData: false,
				success:function(data)
				{	
					//alert("ok");
					//$('#myPagesModal').hide().show();
					//$('.help-block').text('Page Uploaded');
					$('#myPagesModal').fadeOut(function(){
					$(this).modal('hide')
					}).fadeIn("slow",function(){
						$('#pagesform')[0].reset();
						$('.help-block').text('Page Uploaded');
						$(this).modal('show')
					});
				},
				error: function (jqXHR, textStatus, errorThrown)
				{
					alert('Error get data from ajax ');
				}
			});
		}
		function add_pages(bookid){
			$('#pagesform')[0].reset(); // reset form on modals
			$('.form-group').removeClass('has-error'); // clear error class
			$('.help-block').empty();
			$.ajax({
				url : "<?php echo site_url('user_dash/ajax_edit')?>/" + bookid,
				type: "GET",
				dataType: "JSON",
				success: function(data)
				{
					//alert('i am in ' + hellox);
					$('[name="bookID"]').val(data.bookID);
					$('#myPagesModal').modal('show'); // show bootstrap modal when complete loaded
					$('.modal-title').text('Add Pages'); // Set title to Bootstrap modal title
				},
				error: function (jqXHR, textStatus, errorThrown)
				{
					alert('Error get data from ajax ' + bookid);
				}
			});
		}
		var pages = [];
		var ins = 0;
		var ins1 = 0;
		var checks = 0; 
		var checks2 = 0;
		
		function prev(){
			//alert("prev " + pages[ins]);
			if(pages.length != 0){
				if(ins != 0){
					$( '#slideshow_image' ).attr( 'src' , "<?php echo base_url('bookpages/')?>/"+ pages[ins]);
					ins1 = ins + 1;
					ins = ins - 1;
					$('#next_image').prop('disabled', false);
				}
				else{
					if(checks == 1){
						$( '#slideshow_image' ).attr( 'src' , "<?php echo base_url('bookpages/')?>/"+ pages[ins]);
						ins1 = 0;
						ins = 0;
						checks = 0;
					}
					else{
						$('#prev_image').prop('disabled', true);
						$('#slideshow_image').attr( 'src', "<?php echo base_url('defaults/Start.png')?>");
					}
				}
			}
			else{
				$('#next_image').prop('disabled', true);
				$('#prev_image').prop('disabled', true);
				$('#slideshow_image').attr( 'src', "<?php echo base_url('defaults/noPage.png')?>");
			}	
		}
		function nexts(){
				//alert("nexts " +  pages[ins1]);
				checks = 1;
				if(pages.length != 0){
					if(pages.length > ins1){
						if(ins1 == 0){
							$('#prev_image').prop('disabled', false);
							$( '#slideshow_image' ).attr( 'src' , "<?php echo base_url('bookpages/')?>/"+ pages[ins1]);
							ins1 = ins1 + 1;
							ins = 0;
							checks = 0;
						}
						else{
							$('#prev_image').prop('disabled', false);
							$( '#slideshow_image' ).attr( 'src' , "<?php echo base_url('bookpages/')?>/"+ pages[ins1]);
							ins = ins1 - 1;
							ins1 = ins1 + 1;
						}
					}
					else{
						$('#next_image').prop('disabled', true);
						$('#slideshow_image').attr( 'src', "<?php echo base_url('defaults/End.png')?>");
						ins =  pages.length - 1;
					}
				}
				else{
					$('#next_image').prop('disabled', true);
					$('#prev_image').prop('disabled', true);
					$('#slideshow_image').attr( 'src', "<?php echo base_url('defaults/noPage.png')?>");
				}
		}
		$(document).ready(function(){
				$( "#prev_image" ).click(function(){
					prev();
				});
				$( "#next_image" ).click(function(){
					nexts();
				});
		}); 
		var incom;
		function show_pages(bookid){
			$.ajax({
				url : "<?php echo site_url('user_dash/ajax_pages')?>/" + bookid,
				type: "GET",
				dataType: "JSON",
				success: function(data){
					var lal = JSON.stringify(data);
					var oks = JSON.parse(lal);
					$.each(oks, function(i, item){
						pages[i] = item.pageImageLink;
					});
					$('#showPagesModal').modal('show');
					$('.modal-title').text('Show Pages');
					$("#showPagesModal").on("hidden.bs.modal", function(){
						location.reload();
					});
				},
				error: function (jqXHR, textStatus, errorThrown){
					alert("Error ");
				}
			});
		}