import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'round',
  standalone: true,
})
export class RoundPipe implements PipeTransform {

  transform(value: number | null): number | null {
    if(value == null) {
       return null;
    }

    return +value.toFixed(2);
  }
}
