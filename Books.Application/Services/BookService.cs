using AutoMapper;

using Books.Application.DTOs.BookDTOs;

using Books.Application.Interfaces;

using Books.Domain.Entities;


namespace Books.Application.Services;

public class BookService : IBookService

{

    private readonly IBookRepository _repository;

    private readonly IMapper _mapper;

    public BookService(IBookRepository repository, IMapper mapper)

    {

        _repository = repository;

        _mapper = mapper;

    }

    // Створення книги

    public async Task<int?> CreateBookAsync(BookCreateDto dto)

    {

        var book = _mapper.Map<BookEntity>(dto);

        return await _repository.AddBookAsync(book, dto.AuthorsId);

    }

    // Отримати книгу по Id

    public async Task<BookReadDto?> GetBookByIdAsync(int id)

    {

        var book = await _repository.GetBookByIdAsync(id);

        if (book == null) return null;

        var dto = _mapper.Map<BookReadDto>(book);

        return dto;

    }

    // Отримати всі книги

    public async Task<ICollection<BookReadDto>> GetAllBooksAsync()

    {
        var books = await _repository.GetAllBooksAsync();

        return _mapper.Map<ICollection<BookReadDto>>(books);

    }
    //Get chunk
    public async Task<ICollection<BookReadDto>> GetChunkAsync(int pagenum, int limit)
    {
        var books = await _repository.GetChunk(pagenum, limit);
        return _mapper.Map<ICollection<BookReadDto>>(books);
    }

}

